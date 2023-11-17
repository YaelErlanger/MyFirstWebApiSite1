
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

}
function deleteProduct(productId) {
    document.getElementById("items").innerHTML = "";
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))
    let updatedList= products.filter(p => p.productId !== productId);
    sessionStorage.setItem("shoppingBag", []);
    sessionStorage.setItem("shoppingBag", JSON.stringify(updatedList));
    getProducts();

}