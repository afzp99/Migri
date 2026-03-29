import eslintReact from '@eslint-react/eslint-plugin';
import eslintJs from '@eslint/js';
import globals from 'globals';
import tseslint from 'typescript-eslint';

export default [
  eslintJs.configs.recommended,
  ...tseslint.configs.recommended,
  eslintReact.configs['recommended-typescript'],
  {
    files: ['**/*.ts', '**/*.tsx'],
    languageOptions: {
      parser: tseslint.parser,
      parserOptions: {
        projectService: true,
        tsconfigRootDir: import.meta.dirname,
      },
      globals: {
        ...globals.browser,
      },
    },
    rules: {},
  },
  {
    files: ['**/*.js'],
    languageOptions: {
      globals: {
        ...globals.node,
      },
    },
  },
];
