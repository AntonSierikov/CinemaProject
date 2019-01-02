import { Component } from "@angular/core";
import { FiltersValueModel } from "../../models/filters.values.model";
import { SelectedFiltersModel } from "../../models/selected.filters.model";



@Component({
    selector: 'movie-listing-page-filter',
    templateUrl: './filter.component.html',
    styleUrls: ['./filter.component.css']
})
export class FilterComponent{

    filterValues: FiltersValueModel;
    selectedFilter: SelectedFiltersModel;

    getFilterClass(): string{
        return 'primary';
    }

}