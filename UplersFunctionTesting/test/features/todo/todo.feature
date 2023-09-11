Feature: Todo Functional Test

@todo
Scenario Outline: Running Todo Application
Given Todo Page Is Open "http://localhost:4200/"
When  Todo List is Loaded
Then  Create a new Task 
Then  Edit a existing Task "1"
Then  Mark Task as Completed "1"
Then  Delete a existing Task "1"

