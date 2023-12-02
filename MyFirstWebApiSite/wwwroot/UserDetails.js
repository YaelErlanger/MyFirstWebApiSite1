const startOrder = () => {
    window.location.href="products.html"
}

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
        let id = sessionStorage.getItem("userId");

        const res = await fetch(`api/Users/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok)
            throw new Error("error in updating your details ")
        const data = await res.json();
        alert(`Updated${data.FirstName}`)
    }
    catch (er) {
        alert("error...!!, please try again")
    }
}