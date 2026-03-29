import './app.css';

import { AuthProvider, ConnectionStateRenderer, IkonUiSurface, type Toast, useIkonApp, useLazyFont, useToasts } from '@ikonai/sdk-react-ui';
import { registerStandardUiModule, registerLucideIconsModule } from '@ikonai/sdk-react-ui-standard';
import { AuthGuard } from './auth/auth-guard';
import { authConfig } from './env';
import { I18nProvider, useI18n } from './i18n/i18n';
import { en } from './i18n/en';

import { registerProofPointModule } from './components/proof-point/proof-point-module';

function App() {
  if (authConfig.enabled) {
    return (
      <I18nProvider translations={{ en }}>
        <AuthProvider config={authConfig}>
          <AuthGuard config={authConfig}>
            <ConnectedApp />
          </AuthGuard>
        </AuthProvider>
      </I18nProvider>
    );
  }

  return (
    <I18nProvider translations={{ en }}>
      <ConnectedApp />
    </I18nProvider>
  );
}

function ConnectedApp() {
  const loadFont = useLazyFont('https://fonts.googleapis.com/css2?family=Space+Grotesk:wght@400;500;600;700&display=swap');
  const { toasts, dismissToast } = useToasts();

  const app = useIkonApp({
    modules: [registerStandardUiModule, registerLucideIconsModule, registerProofPointModule],
  });

  if (app.accessDeniedReason) {
    return <AccessDeniedScreen reason={app.accessDeniedReason} loadFont={loadFont} />;
  }

  return (
    <ConnectionStateRenderer
      {...app}
      renderIdle={() => null}
      renderConnecting={() => null}
      renderConnectingSlow={() => <ConnectingOverlay loadFont={loadFont} />}
      renderConnected={({ stores, registry, client, onAction, isReconnecting }) => (
        <>
          {isReconnecting && <ReconnectingOverlay loadFont={loadFont} />}
          {toasts.length > 0 && <ToastOverlay toasts={toasts} onDismiss={dismissToast} loadFont={loadFont} />}
          <IkonUiSurface stores={stores} registry={registry} client={client} onAction={onAction} />
        </>
      )}
      renderOffline={() => <OfflineScreen loadFont={loadFont} />}
      renderError={(error) => <ErrorScreen error={error} loadFont={loadFont} />}
    />
  );
}

function ConnectingOverlay({ loadFont }: { loadFont: () => void }) {
  const { t } = useI18n();
  loadFont();
  return (
    <div className="ikon-connecting-overlay">
      <div className="ikon-connecting-chip">
        <div className="ikon-connecting-spinner" />
        <span>{t('connection.connecting')}</span>
      </div>
    </div>
  );
}

function ReconnectingOverlay({ loadFont }: { loadFont: () => void }) {
  const { t } = useI18n();
  loadFont();
  return (
    <div className="ikon-reconnecting-overlay">
      <div className="ikon-reconnecting-chip">
        <div className="ikon-reconnecting-spinner" />
        <span>{t('connection.reconnecting')}</span>
      </div>
    </div>
  );
}

function ToastOverlay({ toasts, onDismiss, loadFont }: { toasts: Toast[]; onDismiss: (id: string) => void; loadFont: () => void }) {
  loadFont();
  return (
    <div className="ikon-toast-overlay">
      {toasts.map((toast) => (
        <div key={toast.id} className={`ikon-toast-overlay-chip ikon-toast-overlay-chip--${toast.level}`} onClick={() => onDismiss(toast.id)}>
          <span className="ikon-toast-overlay-icon">{toast.level === 'error' ? '\u{1F6A8}' : '\u26a0\ufe0f'}</span>
          <div className="ikon-toast-overlay-content">
            <span className="ikon-toast-overlay-component">[{toast.component}]</span>
            <span className="ikon-toast-overlay-message">{toast.message}</span>
          </div>
        </div>
      ))}
    </div>
  );
}

function OfflineScreen({ loadFont }: { loadFont: () => void }) {
  const { t } = useI18n();
  loadFont();
  return (
    <main className="ikon-app">
      <div className="ikon-aurora-1" />
      <div className="ikon-aurora-2" />
      <section className="ikon-hero">
        <h1>{t('connection.offline.title')}</h1>
        <p className="ikon-info">{t('connection.offline.message')}</p>
      </section>
    </main>
  );
}

function AccessDeniedScreen({ reason, loadFont }: { reason: string; loadFont: () => void }) {
  const { t } = useI18n();
  loadFont();
  return (
    <main className="ikon-app">
      <div className="ikon-aurora-1" />
      <div className="ikon-aurora-2" />
      <section className="ikon-hero">
        <h1>{t('connection.accessDenied.title')}</h1>
        <p className="ikon-info">{t('connection.accessDenied.message')}</p>
        <p className="ikon-error">{reason}</p>
      </section>
    </main>
  );
}

function ErrorScreen({ error, loadFont }: { error: string | null; loadFont: () => void }) {
  const { t } = useI18n();
  loadFont();
  return (
    <main className="ikon-app">
      <div className="ikon-aurora-1" />
      <div className="ikon-aurora-2" />
      <section className="ikon-hero">
        <h1>{t('connection.offline.title')}</h1>
        <p className="ikon-info">{t('connection.offline.message')}</p>
        {error && <p className="ikon-error">{error}</p>}
      </section>
    </main>
  );
}

export default App;
