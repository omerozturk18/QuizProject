import { Brand } from "./Brand";
import { CarImage } from "./CarImage";
import { Color } from "./Color";

export interface CarDetail{
  carId:number;
  brand:Brand;
  color:Color;
  modelYear:number;
  dailyPrice:number;
  description:string;
  carImage:CarImage[];
}
