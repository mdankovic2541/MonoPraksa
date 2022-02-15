function sendMessage(){
    alert("Thanks, you clicked on me!")
}

function getTime(){
    document.getElementById("time").innerText = Date();
    console.log("Click")
}

function addName(){
    let name = document.getElementById("name").value;
    console.log(name);
    var ul = document.getElementById("ulitems");
    var li = document.createElement("li");
    li.innerHTML = name;
    console.log(li);
    
    if(name === ""){
        document.getElementById("newItem").setAttribute("hidden","");
    }
    else{
        document.getElementById("newItem").removeAttribute("hidden","");
        document.getElementById("newItem").innerHTML = name;
    }
}

function deleteAll(){
    document.body.style.setProperty("-webkit-transform", "rotate(180deg)", null);
    let count = 0;
    count++;
    alert("Wait for it :) .")
    
}