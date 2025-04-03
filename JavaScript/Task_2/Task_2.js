function createTask() {
    let newtask = document.querySelector(".newTask");
    let tasklist = document.querySelector(".taskList");
  
    let taskDiv = document.createElement("div");
    taskDiv.classList.add("task");
  
    let checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.addEventListener("change", () => {
      if (checkbox.checked) {
        tasktext.style.textDecoration = "line-through";
      } else {
        tasktext.style.textDecoration = "none";
      }
    });
  
    let tasktext = document.createElement("p");
    tasktext.textContent = newtask.value;
  
    let deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";
    deleteButton.onclick = function () {
      tasklist.removeChild(taskDiv);
    };
  
    taskDiv.append(checkbox);
    taskDiv.append(tasktext);
    taskDiv.append(deleteButton);
  
    tasklist.appendChild(taskDiv);
  }