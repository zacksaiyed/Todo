Feature: Todo Functional Test

@todo
Scenario Outline: Running Todo Application
Given Todo Page Is Open "http://localhost:4200/"
When  Todo List is Loaded
Then  Create a new Task
Then  Edit a existing Task

