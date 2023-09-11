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
    chai.expect(await isRecordAdded).to.equal(true);
})