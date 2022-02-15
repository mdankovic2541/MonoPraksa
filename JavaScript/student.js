

function insertUser()
{
    var fname = document.getElementById("firstName").value;
    var lname = document.getElementById("lastName").value;
    var age = document.getElementById("age").value;


    console.log(fname);
    console.log(lname);
    console.log(age);
    var table = document.getElementById("table");
    var row = table.insertRow(0);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    cell1.innerHtml = fname;
    cell2.innerHtml = lname;
    cell3.innerHtml = age;

}

function deleteUser(){
    document.getElementById("table").deleteRow(0);
}


