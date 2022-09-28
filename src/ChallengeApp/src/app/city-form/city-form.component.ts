import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../../services/city.service';
import { switchMap, take } from 'rxjs/operators';
import { of } from 'rxjs';
import { City } from '../../interfaces/city';

@Component({
  selector: 'app-city-form',
  templateUrl: './city-form.component.html',
  styleUrls: ['./city-form.component.scss']
})
export class CityFormComponent implements OnInit {

  cityModel: FormGroup = new FormGroup({
    id: new FormControl(0, Validators.required),
    name: new FormControl('', Validators.required),
    uf: new FormControl('', Validators.required),
  });

  ufs: string[] = ["RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN",
    "PB", "PE", "AL", "SE", "BA", "MG", "ES", "RJ", "SP", "PR", "SC","RS","MS","MT","GO","DF" ];

  constructor(private cityService: CityService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params) => {
        let id = params.get('id') ?? '';
        if (!id) return of();
        return this.cityService.getById(Number(id));
      }), take(1)).subscribe(response => {
        if (!response) return;
        let city: City = {
          id: response.id,
          name: response.name,
          uf: response.uf
        };
        this.cityModel.setValue(city);
      });
  }

  save() {
    if (!this.cityModel.valid) return;
    if (!this.cityModel.value.id)
      this.cityService.create(this.cityModel.value).subscribe(
        response => {
          //TODO: user feedback
          if (response.success) {
            this.router.navigate(['list-city']);
          }
        },
        error => {
          console.log(error)
          //TODO: user feedback
        }
      );
    else
      this.cityService.update(this.cityModel.value).subscribe(
        response => {
          //TODO: user feedback
          if (response.success) {
            this.router.navigate(['list-city']);
          }
        },
        error => {
          console.log(error)
          //TODO: mensagem
        }
      );
  }

  cancel() {
    this.router.navigate(['list-city']);
  }

}
