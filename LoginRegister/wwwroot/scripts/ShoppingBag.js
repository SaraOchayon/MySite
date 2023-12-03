let allPrice=0;
const onLoad = () => {
    allPrice = 0;
    const tbody = document.querySelector('tbody');
    tbody.replaceChildren([]);
    let basketList = JSON.parse(sessionStorage.getItem("basket"));
    for (let i = 0; i < basketList.length;i++)
        drawProduct(basketList[i])
    document.getElementById("itemCount").innerText = basketList.length
    document.getElementById("totalAmount").innerText = allPrice
}
const drawProduct = (prod) => {
  
    allPrice += prod.price
    const temp = document.getElementById('temp-row')
    const clone = temp.content.cloneNode(true)

    clone.querySelector(".image").src = "../pictures/products/" + prod.image.trim()+".png"
    clone.querySelector(".itemName").innerText = prod.description
    clone.querySelector(".price").innerText = prod.price
    clone.querySelector("button").addEventListener('click', () => deleteProduct(prod))


    const tbody = document.querySelector('tbody');
    tbody.appendChild(clone)

   
}
const deleteProduct = (prod) => {
    
    let basketList = JSON.parse(sessionStorage.getItem("basket"));
    let basketListNew = basketList.filter(prodToDel => prodToDel.prodId != prod.prodId);
  
    basketListNew = JSON.stringify(basketListNew)
   
    sessionStorage.setItem("basket", basketListNew )
    onLoad();
}
const makeOrder =async () => {
    if (localStorage.getItem("User") == null) {
        window.location.href = "./LoginRegister.html"
    }
       
    else {
        const order = {
            orderSum: allPrice,
            UserId: JSON.parse(localStorage.getItem("User")).userId,
            orderDate: new Date(),
            orderItems: JSON.parse(sessionStorage.getItem("basket"))
        }
            try {
                const res = await fetch("../api/Order", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(order)

                })
                if (!res.ok)
                    throw new Error("problem")
                else {
                    localStorage.removeItem("User")
                }
            }
            catch (ex) {
                alert("order didnt worked")
            }
            
            
        }
        
}