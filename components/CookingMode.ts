import { RiceCooker } from "../RiceCookerType";

export function setCookingMode(cooker: RiceCooker, time: number): void {
    try {
      if (!cooker.powerOn) {
        throw new Error('The rice cooker must be turned on before setting the cooking mode.');
      }
  
      cooker.cooking = true;
      cooker.cookingTime = time;
      console.log(`The rice cooker is in automatic cooking mode for ${time} minutes.`);
    } catch (error) {
      console.log(error);
    }
}  