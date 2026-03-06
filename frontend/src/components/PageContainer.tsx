export default function PageContainer({ children }: any) {

  return (

    <main className="flex-1 p-8 lg:p-12">

      <div className="max-w-6xl mx-auto">

        {children}

      </div>

    </main>

  )

}