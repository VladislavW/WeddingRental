import {Color, ProductType} from "./catalogModel";

export class EnumExtension {
    static colorToString(color: Color): string{
        switch (color) {
            case Color.Blue:
                return "Blue";
            case Color.Green:
                return "Green";
            case Color.Red:
                return "Red";
            case Color.White:
                return "White";
            case Color.Yellow:
                return "Yellow";
            default:
                return ""
        }
    }

    static typeToString(type: ProductType): string{
        switch (type) {
            case ProductType.Dress:
                return "Dress";
            case ProductType.Flowers:
                return "Flowers";
            case ProductType.Veil:
                return "Veil";
            default:
                return ""
        }
    }
}