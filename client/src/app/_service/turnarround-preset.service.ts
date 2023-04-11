import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { aircraftTurnarroundPreset } from '../_models/aircraftTurnarroundPreset';
import { AircraftTypeIdAndPosCaracteristics } from '../_models/DTOs/OrderCollectionDto';

@Injectable({
  providedIn: 'root'
})
export class TurnarroundPresetService {
  templatesSource = new BehaviorSubject<aircraftTurnarroundPreset[] | null>(null);
  currentTemplates$ = this.templatesSource.asObservable();

  basicUrl = "https://localhost:5001/api/AircraftTurnarroundTemplate"

  constructor(private http: HttpClient) { }

  GetTempForAircraftTypeFilteredByPosCharacteristics(param: AircraftTypeIdAndPosCaracteristics) 
  {
    return this.http.post<aircraftTurnarroundPreset[]>(this.basicUrl + "/aircraftType/filteredByPositionCharacteristics", param).pipe(
      map( (response: aircraftTurnarroundPreset[]) => {
        this.templatesSource.next(response);
        return response;
      })
    )
  }

  loadPresets()
  {
    return this.currentTemplates$;
  }

}
