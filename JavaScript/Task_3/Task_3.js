let studentsList = [];

class Student {
  constructor(name, grade) {
    this.name = name;
    this.grade = grade;
  }
}
let studentName = document.querySelector(".name");
let grade = document.querySelector(".grade");

studentName.addEventListener("input", () => {
  if (isNaN(studentName.value)) {
    document.querySelector(".nameErrorMessage").style.display = "none";
  } else {
    document.querySelector(".nameErrorMessage").style.display = "block";
  }
});

grade.addEventListener("input", () => {
  if (isNaN(grade.value)) {
    document.querySelector(".gradeErrorMessage").style.display = "block";
  } else {
    document.querySelector(".gradeErrorMessage").style.display = "none";
  }
});

function addStudent() {
  studentsList.push(new Student(studentName.value, grade.value));
  studentName.value = "";
  grade.value = "";
}
function showDetails() {
  let gradeList = document.querySelector(".gradeList");
  gradeList.innerHTML = "";
  let studentOL = document.createElement("ol");

  studentsList.map((student, index) => {
    let listItem = document.createElement("li");
    listItem.textContent = `Student Name : ${student.name} Grade : ${student.grade}`;
    studentOL.appendChild(listItem);
    gradeList.append(studentOL);
  });
}
function calulateAvg() {
  sum = 0;
  studentsList.map((student, index) => {
    console.log(student.grade);
    sum += Number(student.grade);
  });
  document.querySelector(".avg").textContent = sum / studentsList.length;
}