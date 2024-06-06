const tblBlog = "blogs";

const uuidv4 = () => {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
};

const readBlog = () => {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);
};
readBlog();

const createBlog = () => {
  const blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }
  // blogs !== null ?
  const requestModel = {
    id: uuidv4(),
    title: "test title",
    author: "test author",
    content: "test content",
  };

  lst.push(requestModel);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
};
createBlog();

const updateBlog = (id, title, author, content) => {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }
  var items = lst.filter((x) => x.id === id);
  console.log(items);
  console.log(items.length);

  if (items.lengthlog == 0) {
    console.log("No Dat Found!");
    return;
  }

  const item = items[0];
  item.title = title;
  item.author = author;
  item.content = content;

  const index = lst.findIndex((x) => x.id == id);
  lst[index] = item;

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
};
// updateBlog("c6c5f487-d03f-4360-a53d-f364c7d8993b","twl","twl","twl");

const deleteBlog = (id) => {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);

  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  var items = lst.filter((x) => x.id === id);
  console.log(items);
  console.log(items.length);

  if (items.length == 0) {
    console.log("No Dat Found!");
    return;
  }

  lst = lst.filter((x) => x.id !== id);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
};

// deleteBlog("c6c5f487-d03f-4360-a53d-f364c7d8993b");
