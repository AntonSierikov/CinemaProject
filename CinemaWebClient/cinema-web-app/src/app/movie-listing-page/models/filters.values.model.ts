import { FilterModel } from "./filter.model";


export class FiltersValueModel{

    genres: FilterModel<GenreModel>[];
    countries: FilterModel<CountryModel>[];
    companyModel: FilterModel<CompanyModel>[];

    groupedCountries: FilterModel<CountryModel>[][];
    groupedCompanies: FilterModel<CountryModel>[][];
}