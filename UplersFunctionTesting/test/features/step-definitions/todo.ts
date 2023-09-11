import { Given,Then,When} from "@wdio/cucumber-framework";
import {TodoPage} from "../../page-objects/todoPage.js";
import { Helper } from "../../helper/helper.ts";
import chai from "chai";

let todoPage = new TodoPage();
let helper = new Helper();
Given("Todo Page Is Open {string}", async function(url:string){
    await todoPage.navigateTo(url);
})

When("Todo List is Loaded",async function() {
   var isListDisplayed= await todoPage.checkIfTodoList();
    chai.expect(isListDisplayed).to.equal(true);
})
Then("Create a new Task", async function() {
    
    var isRecordAdded= await todoPage.addNewTask(helper.generateRandomString(5)); 
    chai.expect(await isRecordAdded.recordExits).to.equal(true);
})

Then("Edit a existing Task {string}", async function(index:string) {
    
    var isRecordUpdated= await todoPage.editTask(helper.generateRandomString(5),parseInt(index)); 
    chai.expect(isRecordUpdated.recordExits).to.equal(true);
})

Then("Mark Task as Completed {string}", async function(index:string) {
    
    var isRecordUpdated= await todoPage.markTaskCompleted(parseInt(index)); 
    chai.expect(isRecordUpdated).to.equal(true);
})

Then("Delete a existing Task {string}", async function(index:string) {
    
    var isRecordUpdated= await todoPage.deleteTask(parseInt(index)); 
    chai.expect(isRecordUpdated.recordExits).to.equal(false);
})
