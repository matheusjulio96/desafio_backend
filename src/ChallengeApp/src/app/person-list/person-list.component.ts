import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { Person } from '../../interfaces/person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-person-list',
  styleUrls: ['./person-list.component.scss'],
  templateUrl: './person-list.component.html'
})
export class PersonListComponent {

  public persons: Person[] = [];
  filter = {
    id: null,
    name: '',
    document: '',
    age: null
  };

  constructor(private personService: PersonService,
    private router: Router) {
    this.personService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
      this.persons = result;
    }, error => console.error(error));
  }

  search() {
    this.personService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
      this.persons = result;
    }, error => console.error(error));
  }

  addRecordClick() {
    this.router.navigate(['form-person']);
  }

  editClick(id: number) {
    this.router.navigate([`form-person`, { id }]);
  }

  deleteClick(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result: any) => {
      if (result.isConfirmed) {
        this.personService.delete(id).subscribe((response: any) => {
          if (response.success)
            Swal.fire(
              'Deleted!',
              'The record has been deleted.',
              'success'
            )
          else
            Swal.fire(
              'Erro!',
              response.message,
              'error'
            )
          this.personService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
            this.persons = result;
          }, error => console.error(error));
        })
      }
    })
  }
}

