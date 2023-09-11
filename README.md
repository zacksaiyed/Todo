# Todo
Created Single Repo For API, App, and Test.

**Steps to set the Application**
UI: Change the API localhost URL if required. In environmentdevelopment.ts file
<img width="672" alt="image" src="https://github.com/zacksaiyed/Todo/assets/59198949/3a89b399-116b-4ff9-a11a-bb1bfd2e58d1">

Functional Test: Change the UI local host URL in todo.feature file.
<img width="744" alt="image" src="https://github.com/zacksaiyed/Todo/assets/59198949/ae16160e-2442-4823-83ad-6f999ca21b56">

For Angular and Functional Test in Cucumber make sure npm i is executed first.

To run the angular application run the command ng serve
To run the cucumber functional test run the command npx wdio wdio.conf.ts

Note: Clone the repo and you can run the projects on your local machine.

The following three Desing patterns have been used :

**Repository Pattern:**
For abstracting away the database logic.
**Dependency Injection:**
For providing dependencies to classes, enhancing testability and modularity.
**Factory Method:**
For creating different types of tasks if the application needs to extend task types in the future.

