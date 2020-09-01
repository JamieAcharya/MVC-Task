function ReplyForm(i) {
    var replyForm = document.getElementById("ReplyForm" + i);
    if (replyForm.style.display === "none") {
        replyForm.style.display = "flex";
    } else {
        replyForm.style.display = "none";
    }
}