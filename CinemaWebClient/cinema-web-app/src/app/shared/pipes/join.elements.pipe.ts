import { Pipe, PipeTransform } from "@angular/core";


@Pipe({name: 'join_elements'})
export class JoinElementsPipe implements PipeTransform{
    
    transform(values: any[], selector: (select: any) => string, separator: string){
        
        let result = '';
        
        values.forEach((value, index, values) => {
            let selected = selector(value) || value;
            if(selected){
                result += selected;
                if(values.length - 1 !== index){
                    result += separator;
                }
            }
        });
        
        return result;
    }
}