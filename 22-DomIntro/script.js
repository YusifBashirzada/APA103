let card = document.getElementById("card");

card.style.width = "350px";
card.style.border = "1px solid #ccc";
card.style.borderRadius = "10px";
card.style.overflow = "hidden";
card.style.fontFamily = "Arial";


let img = document.createElement("img");
img.src = "image/selling_home.jpg";
img.style.width = "100%";
img.style.height = "200px";
img.style.objectFit = "cover";

let content = document.createElement("div");
content.style.padding = "15px";

let title = document.createElement("h3");
title.textContent = "DETACHED HOUSE • 5Y OLD";
title.style.fontSize = "14px";
title.style.color = "gray";

let price = document.createElement("h1");
price.textContent = "$750,000";
price.style.margin = "10px 0";

let address = document.createElement("p");
address.textContent = "742 Evergreen Terrace";
address.style.color = "#555";

let info = document.createElement("div");
info.style.display = "flex";
info.style.justifyContent = "space-between";
info.style.marginTop = "10px";

let bed = document.createElement("span");
bed.innerHTML = '<i class="fa-solid fa-bed"></i> 3 Bedrooms';

let bath = document.createElement("span");
bath.innerHTML = '<i class="fa-solid fa-bath"></i> 2 Bathrooms';

info.appendChild(bed);
info.appendChild(bath);

let realtorDiv = document.createElement("div");
realtorDiv.style.borderTop = "1px solid #eee";
realtorDiv.style.marginTop = "15px";
realtorDiv.style.paddingTop = "10px";

let realtorInfo = document.createElement("div");
realtorInfo.style.display = "flex";
realtorInfo.style.alignItems = "center";
realtorInfo.style.gap = "10px";

let img2 = document.createElement("img");
img2.src = "https://images.squarespace-cdn.com/content/v1/60ef7e7dad55392a3d23ec29/63eaeb84-2e78-4e23-8848-a19d18ef5390/DONTWANNAFEEL2.jpg";
img2.style.width = "50px";
img2.style.height = "50px";
img2.style.borderRadius = "50%";
img2.style.objectFit = "cover";

let realtorTitle = document.createElement("p");
realtorTitle.textContent = "REALTOR";
realtorTitle.style.fontSize = "10px";
realtorTitle.style.color = "gray";
realtorTitle.style.margin = "0";

let textDiv = document.createElement("div");
textDiv.style.display = "flex"
textDiv.style.flexDirection = "column"
textDiv.style.gap = "10px"

let realtorName = document.createElement("p");
realtorName.textContent = "Tiffany Heffner";
realtorName.style.margin = "0";
realtorName.style.fontWeight = "bold";

let phone = document.createElement("p");
phone.textContent = "(555) 555-4321";
phone.style.margin = "0";
phone.style.color = "#555";

textDiv.appendChild(realtorTitle);
textDiv.appendChild(realtorName);
textDiv.appendChild(phone);

realtorInfo.appendChild(img2);
realtorInfo.appendChild(textDiv);

realtorDiv.appendChild(realtorInfo);

content.appendChild(title);
content.appendChild(price);
content.appendChild(address);
content.appendChild(info);
content.appendChild(realtorDiv);

card.appendChild(img);
card.appendChild(content);

let imgContainer = document.createElement("div");
imgContainer.style.position = "relative";
imgContainer.style.width = "100%";
imgContainer.style.height = "200px";

imgContainer.appendChild(img);

let heart = document.createElement("div");
heart.innerHTML = '<i class="fa-regular fa-heart"></i>';
heart.style.position = "absolute";
heart.style.top = "15px";
heart.style.right = "15px";
heart.style.color = "white";
heart.style.fontSize = "22px";
heart.style.cursor = "pointer";
heart.style.textShadow = "0 0 5px rgba(0,0,0,0.5)";

imgContainer.appendChild(heart);

card.appendChild(imgContainer);
card.appendChild(content);