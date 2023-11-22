onLoad = () => {
    let basketList = JSON.parse(sessionStorage.getItem("basket"));
    for (let i = 0; i < basketList.length;i++)
        drawProduct(basketList[i]) 
}
drawProduct = (product) => {
    const template = document.getElementById("temp-row").content;
    const productsRows = document.querySelector("tbody")
    const clone = template.cloneNode(true);
    const image = clone.querySelector("img");
    image.src = "../pictures/products/" + product.image + ".png";
    productsRows.appendChild(clone);
}