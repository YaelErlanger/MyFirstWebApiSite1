function showRegister() {
    const registerTags = document.getElementById("register")
    registerTags.style.visibility = "initial"
}

//function hide() {
//    var p = document.getElementById('logPassword');
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
//}, false);


const goToRegister = () => {
    window.location.href = "register.html";
}

const fetchPwdStrength = async (password) => {
   
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
        ;
        const result = await res.json();
        return result
    }
        //    alert("error ..., please try again")
       
    
 

const checkPwdStrength = async () => {
   
        const passInput = document.getElementById("regPassword")
        const password = passInput.value
        const progress = document.getElementById("progress")
    try {
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
        const Email = document.getElementById("regName").value
        let shtrudel = Email.indexOf('@');

        if (shtrudel == -1) {
            alert("the email must be a valid email address");
            return;
        }
        
        const Password = document.getElementById("regPassword").value
        if (Password.length < 5) {
            alert("the password length must be more then 5");
            return;
        }
        const FirstName = document.getElementById("regFName").value
        const LastName = document.getElementById("regLName").value
        const result = await fetchPwdStrength(Password)
       var progressBar = document.getElementById("progress")
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progressBar.value = result/4
            return
        }

        const user = { Email, Password, FirstName, LastName }
        const res = await fetch("api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok) {
            console.log(res)
         
            return
        }
        const data = await res.json();
        sessionStorage.setItem("user", data)
        
        sessionStorage.setItem("userId",data.userId)
        alert(`Welcome! ${FirstName} `)
        window.location.href = "UserDetails.html";

    }
    catch (er) {
       // alert(er)
    } 
}
async function Login () {
   
    const Email = document.getElementById("logName").value
        const Password = document.getElementById("logPassword").value
    try {
        

        const user = {
            Email, Password
        }
        const res = await fetch("api/Users/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (res.status == 204) {
            alert("user not found")
            return;
        }
        if (!res.ok) { 
            throw new Error("error in login, please try again")
            alert("error in login, please try again")}
        
        const data = await res.json();
        console.log(data)
        sessionStorage.setItem("userId", data.userId)
        sessionStorage.setItem("Email", data.Email)
        window.location.href = "userDetails.html?firstName=" + data.firstName;
    }

    catch (er) {
        alert("error..., please try again")
    }
}

