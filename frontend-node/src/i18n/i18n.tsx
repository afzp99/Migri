import { I18nProvider as BaseI18nProvider, useI18n as useBaseI18n, type I18nContextValue } from '@ikonai/sdk-react-ui';
import type { ReactNode } from 'react';

export interface Translations {
  // Connection states
  'connection.connecting': string;
  'connection.reconnecting': string;
  'connection.offline.title': string;
  'connection.offline.message': string;

  // Auth screen
  'auth.welcome.title': string;
  'auth.welcome.subtitle': string;
  'auth.divider': string;

  // Email login form
  'auth.email.placeholder': string;
  'auth.email.submit': string;
  'auth.email.submitting': string;
  'auth.email.sent.title': string;
  'auth.email.sent.message': string;
  'auth.email.useDifferent': string;
  'auth.email.error.empty': string;
  'auth.email.error.noSpaceId': string;
  'auth.email.error.sendFailed': string;

  // Access denied
  'connection.accessDenied.title': string;
  'connection.accessDenied.message': string;

  // Login buttons
  'auth.button.guest': string;
  'auth.button.provider': string;
  'auth.button.registerPasskey': string;
}

export type TranslationKey = keyof Translations;

export interface I18nProviderProps {
  children: ReactNode;
  translations: Record<string, Translations>;
  defaultLanguage?: string;
  detectLanguage?: boolean;
}

export function I18nProvider({ children, translations, defaultLanguage, detectLanguage }: I18nProviderProps) {
  return (
    <BaseI18nProvider translations={translations} defaultLanguage={defaultLanguage} detectLanguage={detectLanguage}>
      {children}
    </BaseI18nProvider>
  );
}

export function useI18n(): I18nContextValue<Translations> {
  return useBaseI18n<Translations>();
}
