import { deriveAuthUrl } from '@ikonai/sdk';
import type { AuthConfig } from '@ikonai/sdk-react-ui';
import { type FormEvent, useState } from 'react';
import { useI18n } from '../i18n/i18n';

type EmailStatus = 'idle' | 'sending' | 'sent' | 'error';

interface EmailLoginFormProps {
  config: AuthConfig;
}

export function EmailLoginForm({ config }: EmailLoginFormProps) {
  const { t } = useI18n();
  const [email, setEmail] = useState('');
  const [status, setStatus] = useState<EmailStatus>('idle');
  const [errorMessage, setErrorMessage] = useState('');

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    if (!email.trim()) {
      setErrorMessage(t('auth.email.error.empty'));
      setStatus('error');
      return;
    }

    if (!config.spaceId) {
      setErrorMessage(t('auth.email.error.noSpaceId'));
      setStatus('error');
      return;
    }

    setStatus('sending');
    setErrorMessage('');

    try {
      const returnUrl = window.location.origin + window.location.pathname;
      const authUrl = deriveAuthUrl(config.authUrl);
      const response = await fetch(`${authUrl}/email/send`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          email: email.trim(),
          space: config.spaceId,
          return: returnUrl,
        }),
      });

      if (response.ok) {
        setStatus('sent');
      } else {
        const errorText = await response.text().catch(() => t('auth.email.error.sendFailed'));
        setErrorMessage(errorText);
        setStatus('error');
      }
    } catch (err) {
      const message = err instanceof Error ? err.message : t('auth.email.error.sendFailed');
      setErrorMessage(message);
      setStatus('error');
    }
  };

  if (status === 'sent') {
    return (
      <div className="ikon-auth-email-sent">
        <div className="ikon-auth-email-sent-icon">
          <svg viewBox="0 0 24 24" width="48" height="48" fill="currentColor">
            <path d="M20 4H4c-1.1 0-1.99.9-1.99 2L2 18c0 1.1.9 2 2 2h16c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2zm0 4l-8 5-8-5V6l8 5 8-5v2z" />
          </svg>
        </div>
        <p className="ikon-auth-email-sent-title">{t('auth.email.sent.title')}</p>
        <p className="ikon-auth-email-sent-message">
          {t('auth.email.sent.message')} <strong>{email}</strong>
        </p>
        <button
          type="button"
          className="ikon-auth-email-resend"
          onClick={() => {
            setStatus('idle');
            setEmail('');
          }}
        >
          {t('auth.email.useDifferent')}
        </button>
      </div>
    );
  }

  return (
    <form className="ikon-auth-email-form" onSubmit={handleSubmit}>
      <input
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder={t('auth.email.placeholder')}
        className="ikon-auth-email-input"
        disabled={status === 'sending'}
        autoComplete="email"
      />
      <button type="submit" className="ikon-auth-email-button" disabled={status === 'sending'}>
        {status === 'sending' ? (
          <>
            <span className="ikon-auth-email-spinner" />
            {t('auth.email.submitting')}
          </>
        ) : (
          t('auth.email.submit')
        )}
      </button>
      {status === 'error' && errorMessage && <p className="ikon-auth-email-error">{errorMessage}</p>}
    </form>
  );
}
