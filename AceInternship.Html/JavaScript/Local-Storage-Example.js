const tblBlog = "tbl_Blog";

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

//GetBlog
const getBlog = () => {
  let exsitingBlogs = localStorage.getItem(tblBlog);
  return exsitingBlogs ? JSON.parse(exsitingBlogs) : [];
};

//Create Blog
const create = (title, author, content) => {
  let allBlogs = getBlog();

  const blog = {
    id: uuidv4(),
    title,
    author,
    content,
  };

  allBlogs.push(blog);

  let JsonStr = JSON.stringify(allBlogs);

  localStorage.setItem(tblBlog, JsonStr);
};

create("Title 4", "Author 4", "Content 4");

//Read Blog
const read = () => {
  let allBlogs = getBlog();

  allBlogs.map((el) => console.log(el.title, el.author, el.content));
};

read();
