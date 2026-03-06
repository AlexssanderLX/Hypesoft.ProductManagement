"use client"

import Link from "next/link"
import { usePathname } from "next/navigation"

export default function Sidebar() {

  const pathname = usePathname()

  const menu = [
    {
      name: "Dashboard",
      href: "/dashboard",
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" strokeWidth="1.5" viewBox="0 0 24 24">
          <path d="M3 13h8V3H3v10zM13 21h8v-6h-8v6zM13 3v6h8V3h-8zM3 21h8v-6H3v6z" />
        </svg>
      )
    },
    {
      name: "Products",
      href: "/products",
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" strokeWidth="1.5" viewBox="0 0 24 24">
          <path d="M3 7l9-4 9 4-9 4-9-4z"/>
          <path d="M3 7v10l9 4 9-4V7"/>
        </svg>
      )
    },
    {
      name: "Categories",
      href: "/categories",
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" strokeWidth="1.5" viewBox="0 0 24 24">
          <path d="M3 7h5l2 2h11v10a2 2 0 01-2 2H3V7z"/>
        </svg>
      )
    }
  ]

  return (

    <aside className="w-64 min-h-screen bg-slate-900 text-white flex flex-col">

      {/* HEADER */}

      <div className="p-6 border-b border-slate-800">

        <h1 className="text-lg font-semibold tracking-wide">
          Inventory Manager
        </h1>

      </div>

      {/* MENU */}

      <nav className="flex flex-col p-4 space-y-1">

        {menu.map((item) => {

          const active = pathname === item.href

          return (

            <Link
              key={item.href}
              href={item.href}
              className={`

                flex items-center gap-3 px-4 py-3 rounded-lg
                transition-all duration-200 relative

                ${active
                  ? "bg-slate-800 text-white"
                  : "text-slate-400 hover:bg-slate-800 hover:text-white"}

              `}
            >

              {/* BARRA ATIVA */}

              {active && (
                <span className="absolute left-0 top-0 bottom-0 w-1 bg-blue-500 rounded-r"/>
              )}

              {/* ICON */}

              <span className="text-slate-300">
                {item.icon}
              </span>

              {/* TEXT */}

              <span className="text-sm font-medium">
                {item.name}
              </span>

            </Link>

          )

        })}

      </nav>

      {/* FOOTER */}

      <div className="mt-auto p-4 border-t border-slate-800 text-xs text-slate-500">

        Hypesoft System

      </div>

    </aside>

  )

}