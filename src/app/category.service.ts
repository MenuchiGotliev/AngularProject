import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../entities/category.model';
@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) {}
  
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('https://localhost:7137/api/Category')}

  getCategoryById(id:number): Observable<Category> {
    return this.http.get<Category>(`https://localhost:7137/api/Category/${id}`)}
  setNewCategory(category: Category): Observable<Category> {
    return this.http.post<Category>('https://localhost:7137/api/Category', category);}
  updateCategory(category:Category,id:number): Observable<Category> {
    return this.http.put(`https://localhost:7137/api/Category/${id}`,category)}
 }
