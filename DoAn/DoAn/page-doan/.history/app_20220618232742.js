const image = document.querySelector(".detail-image img");
let imgAttr = image.getAttribute("src");
const listImage = document.querySelector(".detail-sub-img");

listImage.addEventListener("click", (e) => {
  image.setAttribute("src", e.target.getAttribute("src"));
});
