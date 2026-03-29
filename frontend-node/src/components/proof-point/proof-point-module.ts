import { type IkonUiModuleLoader, type IkonUiRegistry } from '@ikonai/sdk-react-ui';
import { createProofPointResolver } from './proof-point';

export const loadProofPointModule: IkonUiModuleLoader = () => [createProofPointResolver()];

export function registerProofPointModule(registry: IkonUiRegistry): void {
    registry.registerModule('proof-point', loadProofPointModule);
}
