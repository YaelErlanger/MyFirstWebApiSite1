

const showUpdateTags = () => {
    const updateTags = document.getElementById("update")
    updateTags.style.visibility = "initial" 
}

async function updateUserDetails() {
    try {
        const Email = document.getElementById("updateName").value
        const Password = document.getElementById("updatePassword").value
        const FirstName = document.getElementById("updateFName").value
        const LastName = document.getElementById("updateLName").value
        const user = { Email, Password, FirstName, LastName }
        let id;

        try {
            const storagedEmail = sessionStorage.getItem("Email")
            const storagedPassword = sessionStorage.getItem("Password")
            const res = await fetch(`api/Users/?email=${storagedEmail}&password=${storagedPassword}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            })
            if (res.status == 400) {
                alert("user not found")
                return;
            }
            if (!res.ok) {
                throw new Error("error in login, please try again")
                alert("error in login, please try again")
            }

            const data = await res.json();
            id=data.userId
        }
        catch (er) {
            alert("error................., please try again")
        }

        const res = await fetch(`api/Users/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok)
            throw new Error("error in updating your details in our site")
        //const data = await res.json();
        alert("Updated!")
    }
    catch (er) {
        alert("error...!!, please try again")
    }
}