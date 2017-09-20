export class ChartSliderData {
    currentYear: number;
    minVal: number;
    maxVal: number;
    step: number;

    constructor(currentYear: number) {
        this.currentYear = currentYear;
    }
}