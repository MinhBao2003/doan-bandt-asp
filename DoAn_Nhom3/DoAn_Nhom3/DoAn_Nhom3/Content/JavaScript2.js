var popup = document.getElementById("popup");
var closeButton = document.getElementById("close-button");

function openPopup() {
    popup.style.display = "flex";
}

function closePopup() {
    popup.style.display = "none";
}

closeButton.addEventListener("click", closePopup);

setTimeout(openPopup, 5000);