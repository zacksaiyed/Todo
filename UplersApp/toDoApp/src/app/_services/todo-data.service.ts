import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Todo } from '../_models/todo';
import { getTodoRequest } from '../_request/getTodoRequest';
import { getTodoResponse } from '../_response/getTodoResponse';
import { addUpdateRequest } from '../_request/addUpdateRequest';
import { addUpdateResponse } from '../_response/addUpdateResponse';

@Injectable({
  providedIn: 'root'
})
export class TodoDataService {

baseUrl = environment.apiUrl;

 constructor(private http: HttpClient) { }

 getTodo(request:getTodoRequest){
  return this.http.post<getTodoResponse>(this.baseUrl+'toDo/getToDos/',request);
 }

 addUpdateTodo(request:addUpdateRequest){
  return this.http.post<addUpdateResponse>(this.baseUrl+'toDo/addOrUpdateToDo/',request);
 }

 deleteTodo(request:addUpdateRequest){
  return this.http.post<addUpdateResponse>(this.baseUrl+'toDo/deleteToDo/',request);
 }

 updateTodoAsComplete(request:addUpdateRequest){
  return this.http.post<addUpdateResponse>(this.baseUrl+'toDo/updateTodoAsCompleted/',request);
 }



}
