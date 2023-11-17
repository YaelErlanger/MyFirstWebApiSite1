const getAllProducts = async (name, minPrice, maxPrice, categoryIds) => {
    try {
        let url = 'api/Products';
        if (name || minPrice || maxPrice || categoryIds) url += `?`;

        if (name) url += `&name=${name}`;

        if (minPrice) url += `&minPrice=${minPrice}`;

        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (categoryIds) {
            for (let i = 0; i < categoryIds.length; i++) {
                url += `&categoryIds=${categoryIds[i]}`;
            }
        }


        var res = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (!res.ok) {
            throw new Error("Error in product fetch")
            alert("Error in product fetch")
        }

        const products = await res.json()
        console.log(products);
        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}

const showProducts = async () => {
    const products = await getAllProducts();
    for (let i = 0; i < products.length; i++) {
        var tmpProd = document.getElementById("temp-card");
        var cln = tmpProd.content.cloneNode(true);
        cln.querySelector("img").src = "./images/" + products[i].image;
        cln.querySelector("h1").innerText = products[i].productName;
        cln.querySelector("p.description").innerText = products[i].description;
        cln.querySelector("p.price").innerText = products[i].price + '$';
        cln.querySelector("button").addEventListener('click', () => { addToShoppingBag(products[i]) });
        document.getElementById("PoductList").appendChild(cln);
    }
}



const getAllCategories = async () => {
    try {
        var res =
            await fetch('api/Categories', {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        if (!res.ok) {
            throw new Error("Error on category fetch")
            alert("Error on category fetch")
        }

        const categories = await res.json()
        console.log(categories);
        return categories;
    }
    catch (ex) {
        console.log(ex);
    }
}
const showCategories = async () => {
    const categories = await getAllCategories();
    for (let i = 0; i < categories.length; i++) {
        var tmpCat = document.getElementById("temp-category");
        var cln = tmpCat.content.cloneNode(true);
        cln.querySelector("label").for = categories[i].categoryName;
        cln.querySelector("input").value = categories[i].categoryName;
        cln.querySelector("input").id = categories[i].categoryId;
        cln.querySelector("span.OptionName").innerText = categories[i].categoryName;
        document.getElementById("categoryList").appendChild(cln);
    }
}


const filterProducts = async () => {
    let checkedArr = [];
    var allCategoriesOptions = document.querySelectorAll(".opt");
    for (i = 0; i < allCategoriesOptions.length; i++)
        if (allCategoriesOptions[i].checked) checkedArr.push(allCategoriesOptions[i].id);
    let getMinPrice = document.getElementById("minPrice").value;
    let getMaxPrice = document.getElementById("maxPrice").value;
    let getDesc = document.getElementById("nameSearch").value;
    const products = await getAllProducts(getDesc, getMinPrice, getMaxPrice, checkedArr);
    document.getElementById("PoductList").replaceChildren([]);
    for (let i = 0; i < products.length; i++) {
        var tmpProd = document.getElementById("temp-card");
        var cln = tmpProd.content.cloneNode(true);
        cln.querySelector("img").src = "./images/" + products[i].image;
        cln.querySelector("h1").innerText = products[i].productName;
        cln.querySelector("p.description").innerText = products[i].description;
        cln.querySelector("p.price").innerText = products[i].price + '$';
        document.getElementById("PoductList").appendChild(cln);
    }

}
var cart = [];
var count = 0;

const addToShoppingBag = (product) => {
    cart.push(product);
    count++;
    document.getElementById("ItemsCountText").innerText = count;
    sessionStorage.setItem("shoppingBag", JSON.stringify(cart));
    console.log(cart);
}