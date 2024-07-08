var cart = [];

function addToCart() {
    var itemName = document.getElementById("itemName").value;
    var itemPrice = document.getElementById("itemPrice").value;
    var buyerName = document.getElementById("buyerName").value;
    var item = {
        name: itemName,
        price: itemPrice,
        buyer: buyerName
    };
    cart.push(item);
    updateCart();
}

function removeFromCart(itemName) {
    for (var i = 0; i < cart.length; i++) {
        if (cart[i].name === itemName) {
            cart.splice(i, 1);
            break;
        }
    }
    updateCart();
}

function clearCart() {
    cart = [];
    updateCart();
}

function updateCart() {
    var cartTable = document.getElementById("cart");
    cartTable.innerHTML = "";
    if (cart.length === 0) {
        var row = cartTable.insertRow();
        var cell = row.insertCell();
        cell.colSpan = 3;
        cell.innerHTML = "Giỏ hàng của bạn đang trống.";
    } else {
        var total = 0;
        for (var i = 0; i < cart.length; i++) {
            var item = cart[i];
            var row = cartTable.insertRow();
            var nameCell = row.insertCell();
            nameCell.innerHTML = item.name;
            var priceCell = row.insertCell();
            priceCell.innerHTML = "$" + item.price;
            var buyerCell = row.insertCell();
            buyerCell.innerHTML = item.buyer;
            total += parseInt(item.price);
        }
        var totalCell = document.getElementById("total");
        totalCell.innerHTML = "$" + total;
    }
}