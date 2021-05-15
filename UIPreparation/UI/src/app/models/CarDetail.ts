import { CarImage } from "./CarImage";

export interface CarDetail{
  carId:number;
  brandName:string;
  carName:string;
  colorName:string;
  modelYear:number;
  dailyPrice:number;
  description:string;
  carImage:CarImage[];
}
