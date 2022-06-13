import React, { useState } from "react";
import Editor from "@monaco-editor/react";

export default function CodeEditorWindow ({ onChange, language, code, theme }) {
  const [value, setValue] = useState(code || "");

  const handleEditorChange = (value) => {
    setValue(value);
    onChange(value);
  };

  return (
    <div className="overlay rounded-md overflow-hidden w-full h-full shadow-4xl">
      <Editor
        height="45vh"
        width={`100%`}
        language={language || "csharp"}
        value={value}
        theme={theme}
        defaultValue="// you can write your csharp code there"
        onChange={handleEditorChange}
      />
    </div>
  );
};
