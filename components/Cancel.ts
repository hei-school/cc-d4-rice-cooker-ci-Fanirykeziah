import { RiceCooker } from "../RiceCookerType";

export function cancel(cooker: RiceCooker): void {
    cooker.cooking = false;
    cooker.cookingTime = 0;
    console.log('All operations have been canceled.');
  }
  