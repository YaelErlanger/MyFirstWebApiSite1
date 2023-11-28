
function drowProducts(product) {
    var prod = document.getElementById("temp-row");
    var cln = prod.content.cloneNode(true);
    cln.querySelector("img").src = "./images/" + product.image;
    cln.querySelector(".price").innerText = product.price + "$";
    cln.querySelector(".descriptionColumn").innerText = product.description;
    cln.querySelector(".totalColumn").addEventListener('click', () => { deleteProduct(product.productId) });
    document.getElementById("items").appendChild(cln);
}
function getProducts() {
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))
    for (let i = 0; i < products.length; i++) {
        drowProducts(products[i])
    }
    document.getElementById("itemCount").innerText = sessionStorage.getItem("itemCount");
    document.getElementById("totalAmount").innerText = sessionStorage.getItem("totalAmount");

}
function deleteProduct(productId) {
    document.getElementById("items").innerHTML = "";
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))
    let updatedList= products.filter(p => p.productId !== productId);
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
        const createdOrder = await postOrder(order);
        alert("added successfuly!")
    }
}
const postOrder = async (order) => {
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
    const createdOrder = await res.json();
    console.log(createdOrder);
    return createdOrder;
}

const createOrder = async (stringUser) => {
    const user = JSON.parse(stringUser)
    const cart = JSON.parse(sessionStorage.getItem("shoppingBag"))
    let orderItems = []
    for (let i = 0; i < cart.length; i++) {
        const ord = orderItems.findIndex(o => o.productId == cart[i].productId)
        if (ord > -1)
            orderItems[ord].quantity++;
        else
            orderItems.push({ "productId": cart[i].productId, "quantity": 1 })
    }
    const order = {
        "userId": user,
        "orderSum": sessionStorage.getItem("totalAmount"),
        "orderDate": new Date(),
        "orderItems": orderItems

    }
    return order;
}
//function placeOrder() {
//    let id = sessionStorage.getItem("userId");
//    if (!id) {
//        alert("you must log in befor complating your order");
//        return;
//    }
//    else {
//        createOrder();
//    }
//}
//async function createOrder() {
//    try {
//        const orderDate = new Date();
//        const orderSum = sessionStorage.getItem("totalAmount");
//        const userId = sessionStorage.getItem("userId");
       

       
//        const order = { orderDate, orderSum, userId, orderItems };
//        const res = await fetch("api/Orders", {
//            method: "POST",
//            headers: {
//                "Content-Type": "application/json"
//            },
//            body: JSON.stringify(order)
//        })
//        if (!res.ok) {
//            console.log(res)
//            /// alert(res)
//            return
//        }
//        const data = await res.json();
//        alert(`your order ${data.orderId} created successfuly`);
      

//    }
//    catch (er) {
//        // alert(er)
//    }
//}
//const createOrderObj = async (stringUser) => {
//    const user = JSON.parse(stringUser)
//    const cart = JSON.parse(sessionStorage.getItem("cart"))
//    let orderItems = []
//    for (let i = 0; i < cart.length; i++) {
//        const ord = orderItems.findIndex(o => o.productId == cart[i].id)
//        if (ord > -1)
//            orderItems[ord].quantity++;
//        else
//            orderItems.push({ "productId": cart[i].id, "quantity": 1 })
//    }
//    const order = {
//        "userId": user.id,
//        "orderSum": totalPrice,
//        "orderDate": new Date(),
//        "orderItems": orderItems

//    }
//    return order;
//}

function Login() {
    window.location.href = "Home.html";
}