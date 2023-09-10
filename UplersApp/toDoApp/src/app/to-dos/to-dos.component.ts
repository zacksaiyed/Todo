import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Todo } from '../_models/todo';
import { TodoDataService } from '../_services/todo-data.service';
import { getTodoRequest } from '../_request/getTodoRequest';
import { getTodoResponse } from '../_response/getTodoResponse';
import { addUpdateRequest } from '../_request/addUpdateRequest';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-to-dos',
  templateUrl: './to-dos.component.html',
  styleUrls: ['./to-dos.component.css']
})
export class ToDosComponent implements OnInit {

  todoList:getTodoResponse={} as getTodoResponse;
  addTodo:addUpdateRequest={} as addUpdateRequest;
  editingRowIndex: number = -1;

  constructor(private todoService:TodoDataService,private toastr: ToastrService) {
  }

  ngOnInit(): void { 

    this.loadTodo();
  }

  loadTodo(){
    const request:getTodoRequest={
      title:""
    }

    this.todoService.getTodo(request).subscribe({
      next: response=>this.todoList=response
    })
  }
  addTask(){
    if(this.addTodo.title){
      this.addTodo.action="I"
    this.todoService.addUpdateTodo(this.addTodo).subscribe({
      next:(response)=>{
        if(response.isRecordedAffected){
          this.toastr.success("Record Executed Successfully")
          this.loadTodo();
          this.cancel();
        }
        else{
          this.toastr.error("Record Already Exists"); 
        }
      },
      error:(er)=>{
        this.toastr.error("Something went wrong. Reach out to helpdesk if issue persist");
      }
  })
    }
    else{
      this.toastr.error("Task cannot be empty");
    }
    this.cancel();
  }

  cancel(){
    
    this.addTodo.title="";

  }

  editRow(index: number) {
     this.editingRowIndex=== -1 ? this.editingRowIndex=index : this.editingRowIndex= -1
  }
 

  editRecord(index: number,model:Todo) {
    const editTitle:addUpdateRequest={
      id:model.id,
      title:model.title,
      isCompleted:false,
      isDeleted:false,
      action:"U"
    }

    if(editTitle.title){
      
      this.todoService.addUpdateTodo(editTitle).subscribe({
        next:(response)=>{
          if(response){
            this.toastr.success("Task Created Successfully")
            this.loadTodo();
            this.cancel();
          }
        },
        error:(er)=>{
          this.toastr.error("Something went wrong. Reach out to helpdesk if issue persist");
        }
    })
      }
      else{
        this.toastr.error("Task cannot be empty");
        this.loadTodo();
      }
 
    this.editingRowIndex = -1;
  }

delteTodo(index:number,model:Todo){
  const deleteToDo:addUpdateRequest={
    id:model.id,
    title:model.title,
    isCompleted:false,
    isDeleted:false,
    action:""
  }
  this.todoService.deleteTodo(deleteToDo).subscribe({
    next:(response)=>{
      if(response){
        this.toastr.success("Record Removed.")
        this.loadTodo();
       
      }
    },
    error:(er)=>{
      this.toastr.error("Something went wrong. Reach out to helpdesk if issue persist");
    }
})

}

updateTodoAsComplete(index:number,model:Todo){
  const deleteToDo:addUpdateRequest={
    id:model.id,
    title:model.title,
    isCompleted:false,
    isDeleted:false,
    action:""
  }
  this.todoService.updateTodoAsComplete(deleteToDo).subscribe({
    next:(response)=>{
      if(response){
        this.toastr.success("Record mark as completed")
        this.loadTodo();
        
      }
    },
    error:(er)=>{
      this.toastr.error("Something went wrong. Reach out to helpdesk if issue persist");
    }
})

}

}
