export class ChartSliderData {
    currentYear: number;
    minVal: number;
    maxVal: number;
    step: number;
    isPlaying: boolean;

    constructor(currentYear: number) {
        this.currentYear = currentYear;
        this.isPlaying = false;
    }
}