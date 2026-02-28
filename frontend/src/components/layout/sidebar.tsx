"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";

export default function Sidebar() {
  const pathname = usePathname();

  const linkStyle = (path: string) =>
    `block px-3 py-2 rounded-lg transition ${
      pathname === path
        ? "bg-gray-800 text-white"
        : "text-gray-300 hover:bg-gray-800 hover:text-white"
    }`;

  return (
    <aside className="w-64 h-screen bg-gray-900 text-white p-6">
      <h2 className="text-2xl font-bold mb-8">Hypesoft</h2>

      <nav className="space-y-2">
        <Link href="/" className={linkStyle("/")}>
          Dashboard
        </Link>
        <Link href="/products" className={linkStyle("/products")}>
          Products
        </Link>
        <Link href="/categories" className={linkStyle("/categories")}>
          Categories
        </Link>
      </nav>
    </aside>
  );
}