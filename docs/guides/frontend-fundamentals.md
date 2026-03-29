# Frontend & Custom Components

## Frontend Overview

The frontend is a React app that acts as a thin client. It handles authentication gating, connection to the Ikon server, and renders UI streamed from C#. The main entry point is `app.tsx`.

The component hierarchy depends on whether auth is enabled:
- **Auth enabled:** `I18nProvider` → `AuthProvider` → `AuthGuard` → `ConnectedApp`
- **Auth disabled:** `I18nProvider` → `ConnectedApp`

`ConnectedApp` uses the `useIkonApp` hook and `ConnectionStateRenderer` to manage the connection lifecycle, and `IkonUiSurface` to render the server-driven UI.

### useIkonApp

The `useIkonApp` hook from `@ikonai/sdk-react-ui` establishes the connection to the C# backend and manages UI state.

**Options:**

```typescript
const app = useIkonApp({
  modules: [registerStandardUiModule, registerLucideIconsModule],
  audio: true,            // Enable audio playback (default: true)
  video: true,            // Enable video playback (default: true)
  webRtc: false,          // Enable WebRTC for audio/video transport (default: false)
  backgroundAudio: false, // Allow audio playback when tab is in background (default: false)
  websocket: undefined,   // Force WebSocket transport (default: auto-detected)
  webtransport: undefined,// Force WebTransport transport (default: auto-detected)
  proxy: undefined,       // Force proxy mode (default: auto-detected)
  authConfig: undefined,  // Override auth config (default: from window.__IKON_AUTH_CONFIG__)
  timeouts: undefined,    // Connection timeout configuration (see Connection Lifecycle)
});
```

- `modules` — UI component modules to register. The standard module and Lucide icons module are included by default in scaffolded apps. Custom modules can be added here (see Custom UI Components)
- `audio` / `video` — Enable or disable audio and video playback from the C# app. Enabled by default
- `webRtc` — Use WebRTC transport for audio/video instead of the default SDK-managed pipeline
- `backgroundAudio` — Allow audio to continue playing when the browser tab is not focused, on both desktop and mobile
- `websocket` / `webtransport` / `proxy` — Force a specific transport. By default the SDK auto-selects: WebTransport → WebSocket → proxy variants
- `authConfig` — Override the auto-detected auth configuration. By default read from `window.__IKON_AUTH_CONFIG__` which is injected at build time from `ikon-config.toml`
- `timeouts` — Override connection timeout defaults (see Connection Lifecycle)

**Return values:**

| Property | Type | Description |
|---|---|---|
| `connectionState` | `ConnectionState` | Current connection state |
| `error` | `string \| null` | Current error message |
| `accessDeniedReason` | `string \| null` | Reason if access was denied |
| `stores` | `ReadonlyMap<string, IkonUiStoreEntry> \| undefined` | UI stores from server |
| `client` | `IkonClient \| null` | Active client instance |
| `registry` | `IkonUiRegistry \| null` | UI component registry |
| `onAction` | `(actionId: string, payload: unknown) => void` | Dispatch actions back to C# |
| `isReady` | `boolean` | Whether the connection is ready to render |
| `webRtcVideoStreams` | `Map<number, MediaStream>` | Active WebRTC video streams |

**ConnectionStateRenderer pattern:**

```typescript
<ConnectionStateRenderer
  {...app}
  renderIdle={() => null}
  renderConnecting={() => null}
  renderConnectingSlow={() => <ConnectingOverlay />}
  renderConnected={({ stores, registry, client, onAction, isReconnecting }) => (
    <>
      {isReconnecting && <ReconnectingOverlay />}
      <IkonUiSurface stores={stores} registry={registry} onAction={onAction} />
    </>
  )}
  renderOffline={() => <OfflineScreen />}
  renderError={(error) => <ErrorScreen error={error} />}
/>
```

### Connection Lifecycle

Connection states: `idle` → `connecting` → `connectingSlow` → `connected`, with `reconnecting` on temporary disconnection and `offline` / `offlineError` as terminal states.

**Timeline:**
1. **0–5s:** `connecting` state (show blank or nothing)
2. **5s threshold:** transitions to `connectingSlow` (show a loading indicator)
3. **60s timeout:** if still not connected, transitions to `offline` or `offlineError`
4. **On disconnect:** enters `reconnecting` state — attempt 1 is immediate, attempt 2 after 2s delay. After 2 failed attempts, falls back to full re-authentication
5. **Stability:** after 15s of stable connection, the reconnect counter resets

**Transport selection:** The SDK auto-selects the best transport: WebTransport → WebSocket → proxy variants. Override with the `websocket`, `webtransport`, or `proxy` options on `useIkonApp`, or with query parameters.

**Keepalive:** The server sends periodic keepalive messages. The SDK monitors these with a 15s timeout — if no keepalive is received, the connection is considered lost.

**Timeout configuration** via the `timeouts` option:

| Option | Default | Description |
|---|---|---|
| `slowConnectionThresholdMs` | 5000 | Time before `connectingSlow` state |
| `connectionTimeoutMs` | 60000 | Max time to establish connection |
| `keepaliveTimeoutMs` | 15000 | Max gap between keepalive messages |
| `reconnectBackoffMs` | 2000 | Delay between reconnect attempts |
| `maxReconnectAttempts` | 2 | Fast reconnect attempts before re-auth |

### Query Parameters

The SDK reads `ikon-*` URL query parameters at startup. Both hyphenated (`ikon-proxy`) and underscore (`ikon_proxy`) forms are accepted. Query parameters override `useIkonApp` options.

| Parameter | Type | Description |
|---|---|---|
| `ikon-proxy` | boolean | Force proxy mode on/off |
| `ikon-websocket` | boolean | Force WebSocket transport on/off |
| `ikon-webtransport` | boolean | Force WebTransport transport on/off |
| `ikon-audio` | boolean | Force audio on/off |
| `ikon-video` | boolean | Force video on/off |
| `ikon-webrtc` | boolean | Force WebRTC on/off |
| `ikon-debug` | boolean | Enable SDK debug logging |
| `ikon-lang` | string | Override UI language (e.g. `en`, `fi`) |
| `ikon-server-url` | string | External connect URL for shareable previews |
| `ikon-git-source` | boolean | Enable Git source deployment mode |
| `ikon-git-branch` | string | Git branch for deployment |
| `guest` | — | Auto-login as guest (not `ikon-` prefixed) |

### Authentication

The frontend acts as an optional auth gate — when auth is enabled, users must authenticate before the SDK connects to the server. Auth is configured in the `[Auth]` section of `ikon-config.toml` and injected at build time into `window.__IKON_AUTH_CONFIG__`.

**Component tree:** `AuthProvider` → `AuthGuard` → app content. `AuthGuard` checks the auth state and renders either the auth screen or the protected content.

**Supported login methods:** google, facebook, apple, microsoft, linkedin, github, email (magic link), passkey (WebAuthn), guest.

**Guest auto-login:** Add `?guest` to the URL. If `guest` is included in the configured methods, the user is logged in automatically without seeing the auth screen.

**Session:** Stored in localStorage. Expires after JWT expiry.

**Custom auth:** Two approaches:
1. **Use the `useAuth()` hook** — provides `login(method)`, `logout()`, `getToken()`, `registerPasskey()`. Build your own auth UI while using the SDK's auth backend
2. **Replace `AuthGuard`** — implement fully custom auth logic and pass `authConfig` to `useIkonApp` to control when the SDK connects

The template's `auth-guard.tsx` shows the default implementation: it uses `useAuthGuard({ config, guestUrlParam: 'guest' })` which returns `shouldRenderChildren`, `isCheckingAuth`, `isAuthenticated`, and `error` for conditional rendering.

### Internationalization (i18n)

`I18nProvider` wraps the app with a translations map. Language detection priority (when `detectLanguage` is enabled):
1. `?ikon-lang=` query parameter
2. Browser language (`navigator.language`)
3. `defaultLanguage` prop (defaults to `'en'`)

```typescript
<I18nProvider translations={{ en: enTranslations, fi: fiTranslations }} detectLanguage>
  {children}
</I18nProvider>
```

Use the `useI18n()` hook in components:
- `t(key, params?)` — translate a key with optional parameter interpolation using `{paramName}` syntax
- `locale` — current locale string

The template ships with English translations in `i18n/en.ts`. Add languages by creating translation objects and adding them to the `I18nProvider` `translations` prop.

### Styling

The frontend is fully user-customizable via CSS. `app.css` contains all connection, auth, and overlay styles using `.ikon-*` class names. Override any `.ikon-*` class in your `app.css` to customize the look.

Server-driven styles: the C# app streams CSS via Crosswind to clients, and the SDK injects `<style>` elements dynamically. These styles use Crosswind's utility class system (see Crosswind documentation).

The default template uses a dark theme with aurora gradient effects — all of this is defined in `app.css` and is fully replaceable. Auth screens, connection overlays, and toast notifications all use `.ikon-*` CSS classes that you can override.
## Custom UI Components

When the built-in Ikon.Parallax components are not sufficient, you can integrate any React library as a custom UI component. This requires changes in both the frontend (React) and the C# app (server-side registration).

### Overview

The integration has four parts:

1. **React component** - Implements the UI using any React/JS library
2. **Component resolver** - Tells the Ikon UI system how to render your component type
3. **Module registration** - Registers the resolver with the `useIkonApp` hook
4. **C# extension method** - Provides a typed API for using the component from C# code

### Step 1: React Component and Resolver

Create your React component and a resolver function that maps a node type string to it.

```typescript
// frontend-node/src/lib/my-component/components/my-component.tsx
import { memo } from 'react';
import { type IkonUiComponentResolver, type UiComponentRendererProps, useUiNode } from '@ikonai/sdk-react-ui';

const MyComponentRenderer = memo(function MyComponentRenderer({ nodeId, context, className }: UiComponentRendererProps) {
  const node = useUiNode(context.store, nodeId);
  if (!node) return null;

  const someProp = node.props?.['someProp'] as string | undefined;
  const onClickId = node.props?.['onClickId'] as string | undefined;

  return (
    <div
      className={className}
      onClick={onClickId ? () => context.dispatchAction(onClickId, { clicked: true }) : undefined}
    >
      {someProp}
      {context.renderChildren(node.children ?? [])}
    </div>
  );
});

export function createMyComponentResolver(): IkonUiComponentResolver {
  return (node) => {
    if (node.type !== 'my-component') return undefined;
    return MyComponentRenderer;
  };
}
```

### Step 2: Module Registration

Create a module that registers your resolver with the Ikon UI registry.

```typescript
// frontend-node/src/lib/my-component/my-component-module.ts
import { type IkonUiModuleLoader, type IkonUiRegistry } from '@ikonai/sdk-react-ui';
import { createMyComponentResolver } from './components/my-component';

export const loadMyComponentModule: IkonUiModuleLoader = () => [createMyComponentResolver()];

export function registerMyComponentModule(registry: IkonUiRegistry): void {
  registry.registerModule('my-component', loadMyComponentModule);
}
```

Then add the module to `useIkonApp` in `app.tsx`:

```typescript
const app = useIkonApp({
  modules: [registerStandardUiModule, registerLucideIconsModule, registerMyComponentModule],
});
```

### Step 3: C# Extension Method

Create an extension method on `UIView` that calls `view.AddNode` with your component type and a props dictionary. Use `view.CreateAction<T>` to create action IDs for callbacks.

```csharp
public static class MyComponentExtensions
{
    public static void MyComponent(
        this UIView view,
        string someProp,
        Func<MyClickEventArgs, Task>? onClick = null,
        string[]? style = null,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        string? onClickId = null;

        if (onClick != null)
        {
            onClickId = view.CreateAction<MyClickEventArgs>(args => onClick(args.Value));
        }

        view.AddNode(
            "my-component",
            new Dictionary<string, object?>
            {
                ["someProp"] = someProp,
                ["onClickId"] = onClickId
            },
            style: style,
            file: file,
            line: line);
    }
}
```

### Step 4: Use from C#

```csharp
view.MyComponent("Hello from custom component",
    onClick: async args => { Log.Instance.Info("Clicked!"); },
    style: ["w-full rounded-lg"]);
```

### Key Concepts

- **Node type string** - The string (e.g. `"my-component"`) must match between the C# `view.AddNode` call and the TypeScript resolver check
- **Props dictionary** - C# sends a `Dictionary<string, object?>` that maps directly to React component props
- **Action IDs** - C# creates action IDs via `view.CreateAction<T>()`, passes them as props, and the React component calls `context.dispatchAction(actionId, payload)` to send events back
- **Crosswind styles** - Style arrays passed from C# via `view.AddNode` work with custom components just like built-in components
