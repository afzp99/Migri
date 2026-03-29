import type { Translations } from './i18n';

export const en: Translations = {
  // Connection states
  'connection.connecting': 'Connecting...',
  'connection.reconnecting': 'Reconnecting...',
  'connection.offline.title': 'AI App is offline',
  'connection.offline.message': 'Refresh page to reconnect',

  // Auth screen
  'auth.welcome.title': 'Welcome',
  'auth.welcome.subtitle': 'Sign in to continue',
  'auth.divider': 'or',

  // Email login form
  'auth.email.placeholder': 'Enter your email',
  'auth.email.submit': 'Send magic link',
  'auth.email.submitting': 'Sending...',
  'auth.email.sent.title': 'Check your email',
  'auth.email.sent.message': 'We sent a login link to',
  'auth.email.useDifferent': 'Use a different email',
  'auth.email.error.empty': 'Please enter your email',
  'auth.email.error.noSpaceId': 'Space ID is not configured',
  'auth.email.error.sendFailed': 'Failed to send email',

  // Access denied
  'connection.accessDenied.title': 'Access Denied',
  'connection.accessDenied.message': 'You do not have permission to access this app.',

  // Login buttons
  'auth.button.guest': 'Continue as Guest',
  'auth.button.provider': 'Continue with {provider}',
  'auth.button.registerPasskey': 'Register with Passkey',
};
