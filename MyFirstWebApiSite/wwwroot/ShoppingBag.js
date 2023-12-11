
function drowProducts(product) {
    var prod = document.getElementById("temp-row");
    var cln = prod.content.cloneNode(true);
    cln.querySelector("img").src = "./images/" + product.image;
    cln.querySelector(".price").innerText = product.price + "$";
    cln.querySelector(".descriptionColumn").innerText = product.description;
    cln.querySelector(".totalColumn").addEventListener('click', () => { deleteProduct(product) });
    document.getElementById("items").appendChild(cln);
}
function getProducts() {
    let sum = 0;
    let count = 0;
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))
    for (let i = 0; i < products.length; i++) {
        count++;
        sum += products[i].price;
        drowProducts(products[i])
    }
    sessionStorage.setItem("totalAmount", sum);
    sessionStorage.setItem("itemCount", count);
    document.getElementById("itemCount").innerText = sessionStorage.getItem("itemCount");
    document.getElementById("totalAmount").innerText = sessionStorage.getItem("totalAmount");

}
function deleteProduct(product) {
    document.getElementById("items").innerHTML = "";
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))

    var index = products.findIndex(prod => prod.productId == product.productId);
    if (index !== -1) {
        products.splice(index, 1); 
    }
   


    let updatedList = products;
    sessionStorage.setItem("shoppingBag", []);
    sessionStorage.setItem("shoppingBag", JSON.stringify(updatedList));
    getProducts();

}
const placeOrder = async () => {
    const user = sessionStorage.getItem("userId");
    if (!user) { 
        alert("you must log in befor complating your order");
        Login();
    }
    else {
        const order = await createOrder(user);
         postOrder(order);
        
    }
}
const postOrder = async (order) => {
    try {
        const res = await fetch("api/Orders", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(order)
        })
        if (!res.ok) {
            alert("failed")
            return
        }
        const data = await res.json();
        alert(`your order ${data.orderId} created successfuly`);

        return data;
    }
    catch (e) {
        console.log(e);
    }
}

const createOrder = async (stringUser) => {
    const user = JSON.parse(stringUser)
    const cart = JSON.parse(sessionStorage.getItem("shoppingBag"))
    let orderItems = []
    for (let i = 0; i < cart.length; i++) {
   //     const ord = orderItems.findIndex(o => o.productId == cart[i].productId)
  //      if (ord > -1)
  //          orderItems[ord].quantity++;
  //      else
            orderItems.push({ "productId": cart[i].productId, "quantity": 1 })
    }
    const order = {
        userId: user,
        orderSum: sessionStorage.getItem("totalAmount"),
        orderDate: new Date(),
        orderItemTbls: orderItems

    }
    return order;
}

function Login() {
    window.location.href = "Home.html";
}