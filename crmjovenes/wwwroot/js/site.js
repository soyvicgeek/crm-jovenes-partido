const body = document.querySelector("body")
const sidebar = body.querySelector("nav")
const sidebarToggle = body.querySelector(".sidebar-toggle")

sidebarToggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
})