# Config & CLI

## ikon-config.toml

```toml
# Database configurations for allocating databases for the app (run 'ikon app config' to apply changes)
# Assigned database connection info is available via app.Databases in the app. Use 'ikon app db' commands to manage databases.
# Format: "name:type" or "name:type:tier" - valid types: postgres - valid tiers: shared, dedicated-small
# Examples: "mydb:postgres", "mydb:postgres:dedicated-small"
Databases = []

# Endpoint configurations for exposing the app externally (assigned port numbers and public URLs are available via app.Endpoints in the app)
# Format: "name:protocol" - valid protocols: http, https, tls, tcp
# Examples: "api:https", "webhooks:http", "gameserver:tcp"
Endpoints = []

# Activation configuration for the app (app activation is separate from deployment)
[Activation]
# Whether to stop all active sessions of the app when a version of the app is activated
StopSessions = false

# Authentication configuration for the app frontend
[Auth]
# Whether the frontend requires authentication before connection to the app is established
Enabled = false
# Available methods: google, facebook, apple, microsoft, linkedin, github, email, guest
Methods = ["google", "facebook", "apple"]
# If non-empty, only allow users with email addresses from these domains to authenticate (e.g. ["mycompany.com"])
DomainAllowlist = []

# Target information for deployment (automatically configured with 'ikon app config')
# Use environment-specific config files: ikon-config.development.toml, ikon-config.production.toml
[Target]
OrganisationId = ""
SpaceId = ""
ChannelId = ""
Name = ""
```

## CLI Commands

### Project Management

- `ikon app new <name>`: create a new Ikon AI app
- `ikon app build`: build the app
- `ikon app clean`: clean build artifacts
- `ikon app run`: run in local dev mode (starts both C# app and Vite frontend dev server)
  - `--host-lan`: run with LAN hostname instead of localhost
  - `--public-access`: expose to public internet
  - `--host <ip>`: run with explicit hostname
  - `--log-trace` / `--log-debug`: enable verbose logging
  - `--debug`: enable debug mode
  - `--skip-npm-install`: skip npm install step
- `ikon app stop`: stop a running app instance (`--pid <id>` or `--all`)
- `ikon app info`: show running app instance info (URLs, PIDs)

### Configuration & Deployment

- `ikon app config`: configure the app for cloud deployment
- `ikon app status`: check app configuration status
- `ikon app target list`: list all configured targets
- `ikon app update`: update app Ikon NuGet and NPM package references to newest versions
- `ikon app bundle`: create the app bundle without deploying
- `ikon app deploy`: create the app bundle and deploy it to the cloud
- `ikon app deploy list`: list deployed app bundles
- `ikon app export`: export an app to a distributable zip-file or directory
- `ikon app docs`: (re)generate app documentation

### Database Management

- `ikon app db connection-string`: print the database connection string
- `ikon app db migrate add <name>`: create a new EF Core migration
- `ikon app db migrate apply`: apply pending EF Core migrations
- `ikon app db migrate list`: list EF Core migrations and their status
- `ikon app db migrate remove`: remove the last unapplied EF Core migration
- `ikon app db reset`: reset the database by dropping and recreating it

### Version Control

- `ikon app save`: save all changes to version control
- `ikon app sync`: download the latest version from version control
- `ikon app changes`: show uncommitted changes
- `ikon app compare`: compare current files with a saved version
- `ikon app discard`: discard all uncommitted changes
- `ikon app history`: list saved versions
- `ikon app label`: create or update a named label for the current version
- `ikon app restore`: switch local files to a version
- `ikon app promote`: make an older version the new latest in version control

### Testing

- `ikon app test record <name>`: record a Playwright test for the app
- `ikon app test play [name]`: play back recorded tests (`--all`, `--headless`)

Note: during development, there is no need to run `ikon app build` if app is running because the Ikon server also hot reloads all C# changes. To see any compilation errors, search for latest `ikon-server-*.log` under the root `build/app/artifacts/` directory.
