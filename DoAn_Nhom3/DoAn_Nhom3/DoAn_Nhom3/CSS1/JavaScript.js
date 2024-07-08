var carouselIndex = 0;
var carouselItems = document.querySelectorAll(".carousel-item");

function showNextCarouselItem() {
    // Ẩn hết các hình ảnh trong carousel
    for (var i = 0; i < carouselItems.length; i++) {
        carouselItems[i].classList.remove("active");
    }

    // Tăng giá trị của biến carouselIndex
    carouselIndex++;

    // Nếu carouselIndex vượt quá số lượng hình ảnh trong carousel, thiết lập lại giá trị carouselIndex thành 0
    if (carouselIndex >= carouselItems.length) {
        carouselIndex = 0;
    }

    // Hiển thị hình ảnh tiếp theo trong carousel
    carouselItems[carouselIndex].classList.add("active");
}

setInterval(showNextCarouselItem, 5000); // Chuyển đổi hình ảnh trong carousel mỗi 5 giây