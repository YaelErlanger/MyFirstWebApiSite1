function show() {
    var p = document.getElementById('pwd');
    p.setAttribute('type', 'text');
}

function hide() {
//    var p = document.getElementById('pwd');
//    p.setAttribute('type', 'password');
//}

//var pwShown = 0;

//document.getElementById("eye").addEventListener("click", function () {
//    if (pwShown == 0) {
//        pwShown = 1;
//        show();
//    } else {
//        pwShown = 0;
//        hide();
//    }
}//, false);


const goToRegister = () => {
    window.location.href = "register.html";
}

const fetchPwdStrength = async (password) => {
    debugger
        const res = await fetch("api/Users/checkYourPass", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(password)
        })
        console.log(res)   

        if (!res.ok)
            throw new Error("error in checking pwd strength")
        debugger;
        const result = await res.json();
        return result
    }
        //    alert("error ..., please try again")
        console.log(ex)   
    
    }

const checkPwdStrength = async () => {
    try {
        const passInput = document.getElementById("regPassword")
        const password = passInput.value
        const progress = document.getElementById("progress")
        const result= await fetchPwdStrength(password)
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progress.value = result/4
        }
        else {
            var progressBar = document.getElementById("progress")
            progressBar.value = (result / 4)
            alert("strong password!")
        }
       
    }
    catch (er) {
        alert("error in checking yor pass, please try again")
    } 
}
async function Register() {

    try {
        const UserName = document.getElementById("regName").value
        const Password = document.getElementById("regPassword").value
        const FirstName = document.getElementById("regFName").value
        const LastName = document.getElementById("regLName").value
        const result = await fetchPwdStrength(Password)
       var progressBar = document.getElementById("progress")
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progressBar.value = result/4
            return
        }

        const user = { UserName, Password, FirstName, LastName }
        const res = await fetch("api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok) {
            console.log(res)
           /// alert(res)
            return
        }
            
        sessionStorage.setItem("FirstName", FirstName)
        sessionStorage.setItem("LastName", LastName)
        alert(`Welcome! ${FirstName} `)
    }
    catch (er) {
        alert(er)
    } 
}
async function Login () {
    try {
        const UserName = document.getElementById("logName").value
        const Password = document.getElementById("logPassword").value

        const res = await fetch(`api/Users/?email=${UserName}&password=${Password}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        })
        if (res.status == 204) {
            alert("user not found")
            ShowRegisterTags()
            return;
        }
        if (!res.ok) { 
            throw new Error("error in login, please try again")
            alert("error in login, please try again")}
        
        const data = await res.json();
        console.log(data)
        sessionStorage.setItem("Password", data.password)
        sessionStorage.setItem("UserName", data.userName)
        window.location.href = "UserDetails.html?firstName=" + data.firstName
    }

    catch (er) {
        alert("error..., please try again")
    }
}

