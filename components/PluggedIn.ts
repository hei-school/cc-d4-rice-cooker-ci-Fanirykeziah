import { RiceCooker } from "../RiceCookerType";

function plugIn(cooker: RiceCooker): void {
    cooker.pluggedIn = true;
    console.log('The rice cooker is plugged in.');
}

export default plugIn;