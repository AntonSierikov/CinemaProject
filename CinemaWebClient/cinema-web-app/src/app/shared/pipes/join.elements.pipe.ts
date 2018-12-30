import { Pipe, PipeTransform } from "@angular/core";


@Pipe({name: 'join-elements'})
export class JoinElementsPipe implements PipeTransform{
    
    transform(values: any[], selector: (select: any) => string, separator: string){
        
        let result: string;
        
        values.forEach((value, index, values) => {
            result += selector(value);
            if(values.length - 1 !== index){
                result += separator;
            }
        });
        
        return result;
    }
}