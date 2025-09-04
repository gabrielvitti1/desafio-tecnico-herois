import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule, MatTableDataSource, MatTable } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator'; // Se não usar, remova
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { HeroisService } from 'src/app/services/herois.service';
import { Heroi } from 'src/app/models/heroi';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Router } from '@angular/router';

@Component({
  selector: 'app-herois',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './herois.component.html',
  styleUrls: ['./herois.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class HeroisComponent implements OnInit, AfterViewInit {
  dataSource = new MatTableDataSource<Heroi>([]);
  displayedColumns: string[] = ['nome', 'nomeHeroi', 'dataNascimento', 'altura', 'peso', 'actions'];
  columnsToDisplayWithExpand: string[] = [...this.displayedColumns, 'expand'];
  expandedElement: Heroi | null = null;

  @ViewChild(MatSort) sort!: MatSort;

  constructor(private service: HeroisService, private router: Router) {}

  ngOnInit(): void {
    this.loadHerois();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.sort.disableClear = true;

    this.dataSource.filterPredicate = (data: Heroi, filter: string) => {
      const lowerFilter = filter.trim().toLowerCase();
      return data.nome.toLowerCase().includes(lowerFilter) ||
             data.nomeHeroi.toLowerCase().includes(lowerFilter);
    };
  }

  loadHerois(): void {
    this.service.getHerois().subscribe(herois => {
      this.dataSource.data = herois;
    });
  }

  toggle(row: Heroi): void {
    this.expandedElement = (this.expandedElement === row) ? null : row;
  }

  edit(heroi: Heroi): void {
    this.router.navigate(['/herois', heroi.id, 'editar']);
  }

  addNovo(): void {
    this.router.navigate(['/herois/novo']);
  }

  delete(id: number): void {
    this.service.deleteHero(id).subscribe();
    this.dataSource.data = this.dataSource.data.filter(h => h.id !== id);
  }

}